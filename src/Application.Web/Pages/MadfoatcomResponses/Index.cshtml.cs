using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Application.MadfoatcomResponses;
using Application.Shared;

namespace Application.Web.Pages.MadfoatcomResponses
{
    public abstract class IndexModelBase : AbpPageModel
    {
        public int? BillerCodeFilterMin { get; set; }

        public int? BillerCodeFilterMax { get; set; }
        public string? BillingNoFilter { get; set; }
        public string? BillNoFilter { get; set; }
        public string? DueAmtFilter { get; set; }
        public string? ValidationCodeFilter { get; set; }
        public string? ServiceTypeFilter { get; set; }
        public string? PrepaidCatFilter { get; set; }
        public string? AmountFilter { get; set; }
        public int? SetBnkCodeFilterMin { get; set; }

        public int? SetBnkCodeFilterMax { get; set; }
        public string? AcctNoFilter { get; set; }
        public string? TransferReasonFilter { get; set; }
        public string? ReceivingCountryFilter { get; set; }
        public string? CustNameFilter { get; set; }
        public string? EmailFilter { get; set; }
        public string? PhoneFilter { get; set; }
        public int? RecCountFilterMin { get; set; }

        public int? RecCountFilterMax { get; set; }
        public string? BillStatusFilter { get; set; }
        public string? DueAmountFilter { get; set; }
        public DateTime? IssueDateFilterMin { get; set; }

        public DateTime? IssueDateFilterMax { get; set; }
        public DateTime? OpenDateFilterMin { get; set; }

        public DateTime? OpenDateFilterMax { get; set; }
        public DateTime? DueDateFilterMin { get; set; }

        public DateTime? DueDateFilterMax { get; set; }
        public DateTime? ExpiryDateFilterMin { get; set; }

        public DateTime? ExpiryDateFilterMax { get; set; }
        public DateTime? CloseDateFilterMin { get; set; }

        public DateTime? CloseDateFilterMax { get; set; }
        public string? BillTypeFilter { get; set; }
        [SelectItems(nameof(AllowPartBoolFilterItems))]
        public string AllowPartFilter { get; set; }

        public List<SelectListItem> AllowPartBoolFilterItems { get; set; } =
            new List<SelectListItem>
            {
                new SelectListItem("", ""),
                new SelectListItem("Yes", "true"),
                new SelectListItem("No", "false"),
            };
        public string? UpperFilter { get; set; }
        public string? LowerFilter { get; set; }
        public int? BillsCountFilterMin { get; set; }

        public int? BillsCountFilterMax { get; set; }
        public string? JOEBPPSTrxFilter { get; set; }
        public DateTime? ProcessDateFilterMin { get; set; }

        public DateTime? ProcessDateFilterMax { get; set; }
        public string? STMTDateFilter { get; set; }

        protected IMadfoatcomResponsesAppService _madfoatcomResponsesAppService;

        public IndexModelBase(IMadfoatcomResponsesAppService madfoatcomResponsesAppService)
        {
            _madfoatcomResponsesAppService = madfoatcomResponsesAppService;
        }

        public virtual async Task OnGetAsync()
        {

            await Task.CompletedTask;
        }
    }
}