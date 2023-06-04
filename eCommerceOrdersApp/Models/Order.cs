using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceOrdersApp.Models
{
    public class Order : IValidatableObject
    {
        #region Properties

        public int OrderNumber { get; set; }

        [Required(ErrorMessage = "'{0}' is required and can not be null or empty")]
        [DisplayName("Order Date")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "'{0}' is required and can not be null or empty")]
        [DisplayName("Invoice Price")]
        public double? InvoicePrice { get; set; }

        [Required(ErrorMessage = "'{0}' is required and can not be null or empty")]
        public List<Product>? Products { get; set; } = new List<Product>();

        #endregion

        #region Ctors

        public Order()
        {
            OrderNumber = RandomOrderNumber();
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Order Number: {OrderNumber}\nOrder Date: {OrderDate}\nInvoice Price: {InvoicePrice}\nProducts:\n{PrintProducts(Products)}";
        }

        private static string? PrintProducts(List<Product>? productsToPrint)
        {
            string products = "";
            for (int i = 0; i < productsToPrint.Count; i++)
            {
                Product? product = productsToPrint[i];
                products += product.ToString();
            }

            return products;
        }

        private static int RandomOrderNumber()
        {
            var random = new Random();
            int randomOrderNumber = random.Next();

            return randomOrderNumber;
        }

        public IEnumerable<ValidationResult?> Validate(ValidationContext validationContext)
        {
            if (Products?.Count > 0)
            {
                double? productsPriceSum = 0;

                foreach (var product in Products)
                {
                    productsPriceSum += (product.Price * product.Quantity);
                }
                if (InvoicePrice < productsPriceSum || InvoicePrice > productsPriceSum)
                {
                    yield return new ValidationResult("Invoice Price should equal to Products Price sum", new[] { nameof(InvoicePrice) });
                }
            }

            yield return null;
        }

        #endregion
    }
}
