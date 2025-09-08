using System.ComponentModel.DataAnnotations;

namespace AirbnbPricePred.WebApp.Models
{
    public class RentalRequest
    {
        [Display(Name = "Neighbourhood group")]
        public string NeighbourhoodGroup { get; set; } = string.Empty;

        [Display(Name = "Neighbourhood")]
        public string Neighbourhood { get; set; } = string.Empty;

        [Display(Name = "Room type")]
        public string RoomType { get; set; } = string.Empty;

        [Display(Name = "Minimum nights")]
        [Range(1, 365)]
        public int MinimumNights { get; set; } = 1;

        [Display(Name = "Number of reviews")]
        [Range(0, int.MaxValue)]
        public int NumberOfReviews { get; set; } = 0;

        [Display(Name = "Last review date")]
        public DateTime? LastReviewDate { get; set; } = null;

        [Display(Name = "Reviews per month")]
        [Range(0, double.MaxValue)]
        public double ReviewsPerMonth { get; set; } = 0.0;
    }
}
