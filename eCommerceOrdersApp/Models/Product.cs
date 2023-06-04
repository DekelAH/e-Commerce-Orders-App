using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerceOrdersApp.Models
{
    public class Product
    {
        #region Properties

        [Required(ErrorMessage = "'{0}' is required and can not be null or empty")]
        [DisplayName("Product Code")]
        public int? ProductCode { get; set; }

        [Required(ErrorMessage = "'{0}' is required and can not be null or empty")]
        [Range(0, 1000000, ErrorMessage = "'{0}' should be between {1} and {2}")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "'{0}' is required and can not be null or empty")]
        [Range(0, 100, ErrorMessage = "'{0}' should be between {1} and {2}")]
        public int? Quantity { get; set; }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"Product Code: {ProductCode}\nPrice: {Price}\nQuantity: {Quantity}\n";
        }

        #endregion
    }
}
