using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Goods> goods;

        public MainPage()
        {
            InitializeComponent();

            goods = new ObservableCollection<Goods>
            {
                new Product
                {
                    Price = 65,
                    CountryOfOrigin = "Україна",
                    Name = "Шоколадка",
                    PackagingDate = DateTime.Now,
                    Description = "Шоколадна",
                    ExpirationDate = DateTime.Now.AddDays(14),
                    Quantity = 1,
                    UnitOfMeasurement = "шт."
                },
                new Book
                {
                    Price = 500,
                    CountryOfOrigin = "Україна",
                    Name = "Хіба ревуть воли, як ясла повні?",
                    PackagingDate = DateTime.Now,
                    Description = "Цікава",
                    NumberOfPages = 702,
                    Publisher = "Yakaboo",
                    ListOfAuthors = new List<string> { "Панас Мирний", "Іван Білик" }
                }
            };

            goodsListView.ItemsSource = goods;
        }

        private void AddGoods_Clicked(object sender, EventArgs e)
        {
            try
            {
                string productType = (string)goodsTypePicker.SelectedItem;

                decimal price = decimal.Parse(priceEntry.Text);
                string origin = originEntry.Text;
                string name = nameEntry.Text;
                DateTime packagingDate = DateTime.Parse(packagingDateEntry.Text);
                string description = descriptionEntry.Text;

                if (productType == "Продукт")
                {
                    goods.Add(new Product
                    {
                        Price = price,
                        CountryOfOrigin = origin,
                        Name = name,
                        PackagingDate = packagingDate,
                        Description = description,
                        ExpirationDate = DateTime.Now.AddDays(3),
                        Quantity = 2,
                        UnitOfMeasurement = "шт."
                    });
                }
                else if (productType == "Книга")
                {
                    goods.Add(new Book
                    {
                        Price = price,
                        CountryOfOrigin = origin,
                        Name = name,
                        PackagingDate = packagingDate,
                        Description = description,
                        NumberOfPages = 100,
                        Publisher = "А-ба-ба-га-ла-ма",
                        ListOfAuthors = new List<string> { "Тарас Шевченко", "Леся Українка", "Іван Франко" }
                    });
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Помилка", "Неправильний формат даних: " + ex.Message, "OK");
            }
        }

        private async void DeleteGoods_Clicked(object sender, EventArgs e)
        {
            string input = await DisplayPromptAsync("Введення номеру", "Введіть номер товару, який ви хочете видалити");

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int productNumber))
            {
                if (productNumber >= 1)
                {
                    if (productNumber <= goods.Count)
                    {
                        Goods selectedGoods = goods[productNumber - 1];
                        goods.Remove(selectedGoods);
                    }
                    else
                    {
                        await DisplayAlert("Помилка", "Невірний номер товару", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Помилка", "Введіть коректний номер товару", "OK");
                }
            }
        }
    }

}