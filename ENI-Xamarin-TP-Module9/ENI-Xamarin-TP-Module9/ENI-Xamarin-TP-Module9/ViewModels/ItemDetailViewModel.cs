using System;

using ENI_Xamarin_TP_Module9.Models;

namespace ENI_Xamarin_TP_Module9.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
