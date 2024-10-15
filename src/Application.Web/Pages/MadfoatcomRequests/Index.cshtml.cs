using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Application.MadfoatcomRequests;
using Application.Shared;

namespace Application.Web.Pages.MadfoatcomRequests
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public int? BillerCodeFilterMin { get; set; }

        public int? BillerCodeFilterMax { get; set; }
        public string? BillingNoFilter { get; set; }
        public string? BillNoFilter { get; set; }
        public string? ServiceTypeFilter { get; set; }
        public string? PrepaidCatFilter { get; set; }
        public decimal? DueAmtFilterMin { get; set; }

        public decimal? DueAmtFilterMax { get; set; }
        public string? ValidationCodeFilter { get; set; }
        public string? JOEBPPSTrxFilter { get; set; }
        public string? BankTrxIdFilter { get; set; }
        public string? BankCodeFilter { get; set; }
        public string? PmtStatusFilter { get; set; }
        public decimal? PaidAmtFilterMin { get; set; }

        public decimal? PaidAmtFilterMax { get; set; }
        public decimal? FeesAmtFilterMin { get; set; }

        public decimal? FeesAmtFilterMax { get; set; }
        [SelectItems(nameof(FeesOnBillerBoolFilterItems))]
        public string FeesOnBillerFilter { get; set; }

        public List<SelectListItem> FeesOnBillerBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        public DateTime? ProcessDateFilterMin { get; set; }

        public DateTime? ProcessDateFilterMax { get; set; }
        public DateTime? StmtDateFilterMin { get; set; }

        public DateTime? StmtDateFilterMax { get; set; }
        public string? AccessChannelFilter { get; set; }
        public string? PaymentMethodFilter { get; set; }
        public string? PaymentTypeFilter { get; set; }
        public decimal? AmountFilterMin { get; set; }

        public decimal? AmountFilterMax { get; set; }
        public int? SetBnkCodeFilterMin { get; set; }

        public int? SetBnkCodeFilterMax { get; set; }
        public string? AcctNoFilter { get; set; }
        public string? NameFilter { get; set; }
        public string? PhoneFilter { get; set; }
        public string? AddressFilter { get; set; }
        public string? EmailFilter { get; set; }

        protected IMadfoatcomRequestsAppService _madfoatcomRequestsAppService;

        public IndexModelBase(IMadfoatcomRequestsAppService madfoatcomRequestsAppService)
        {
            _madfoatcomRequestsAppService = madfoatcomRequestsAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}