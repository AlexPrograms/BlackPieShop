using BlackPieShop.Models;
using Microsoft.AspNetCore.Components;

namespace BlackPieShop.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
