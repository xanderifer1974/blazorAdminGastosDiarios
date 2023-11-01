using Microsoft.AspNetCore.Components;
using System;

namespace BlazorAdminGastosDiarios.UI.Components
{
    public partial class TabControl
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public RenderFragment<TabPage> TabTitulo { get; set; }

        public TabPage ActivePage { get; set; }

        public List<TabPage> Pages { get; set; } = new List<TabPage>();

        internal void AddPage(TabPage Tabpage)
        {
            Pages.Add(Tabpage);

            if (Pages.Count == 1)
                ActivePage = Tabpage;

            StateHasChanged();
        }

        protected string GetButtonClass(TabPage page)
        {
            return page == ActivePage ? "btn-primary" : "btn-secondary";
        }

        protected void ActivatePage(TabPage page)
        {
            ActivePage = page;
        }
    }
}
