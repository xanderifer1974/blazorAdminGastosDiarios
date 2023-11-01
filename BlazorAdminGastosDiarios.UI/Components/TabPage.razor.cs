using Microsoft.AspNetCore.Components;

namespace BlazorAdminGastosDiarios.UI.Components
{
    public partial class TabPage
    {
        [CascadingParameter]
        private TabControl Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Text { get; set; }

        protected override Task OnInitializedAsync()
        {
            if(Parent == null)
                throw new ArgumentNullException(nameof(Parent),"Uma TabPage deve possuir um TabControl");

            Parent.AddPage(this);


            return base.OnInitializedAsync();   
        }
       
    }
}
