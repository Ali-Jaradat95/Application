$(function () {
    var l = abp.localization.getResource("Application");
	
	var madfoatcomResponseService = window.application.madfoatcomResponses.madfoatcomResponses;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "MadfoatcomResponses/CreateModal",
        scriptUrl: abp.appPath + "Pages/MadfoatcomResponses/createModal.js",
        modalClass: "madfoatcomResponseCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "MadfoatcomResponses/EditModal",
        scriptUrl: abp.appPath + "Pages/MadfoatcomResponses/editModal.js",
        modalClass: "madfoatcomResponseEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            billerCodeMin: $("#BillerCodeFilterMin").val(),
			billerCodeMax: $("#BillerCodeFilterMax").val(),
			billingNo: $("#BillingNoFilter").val(),
			billNo: $("#BillNoFilter").val(),
			dueAmt: $("#DueAmtFilter").val(),
			validationCode: $("#ValidationCodeFilter").val(),
			serviceType: $("#ServiceTypeFilter").val(),
			prepaidCat: $("#PrepaidCatFilter").val(),
			amount: $("#AmountFilter").val(),
			setBnkCodeMin: $("#SetBnkCodeFilterMin").val(),
			setBnkCodeMax: $("#SetBnkCodeFilterMax").val(),
			acctNo: $("#AcctNoFilter").val(),
			transferReason: $("#TransferReasonFilter").val(),
			receivingCountry: $("#ReceivingCountryFilter").val(),
			custName: $("#CustNameFilter").val(),
			email: $("#EmailFilter").val(),
			phone: $("#PhoneFilter").val(),
			recCountMin: $("#RecCountFilterMin").val(),
			recCountMax: $("#RecCountFilterMax").val(),
			billStatus: $("#BillStatusFilter").val(),
			dueAmount: $("#DueAmountFilter").val(),
			issueDateMin: $("#IssueDateFilterMin").val(),
			issueDateMax: $("#IssueDateFilterMax").val(),
			openDateMin: $("#OpenDateFilterMin").val(),
			openDateMax: $("#OpenDateFilterMax").val(),
			dueDateMin: $("#DueDateFilterMin").val(),
			dueDateMax: $("#DueDateFilterMax").val(),
			expiryDateMin: $("#ExpiryDateFilterMin").val(),
			expiryDateMax: $("#ExpiryDateFilterMax").val(),
			closeDateMin: $("#CloseDateFilterMin").val(),
			closeDateMax: $("#CloseDateFilterMax").val(),
			billType: $("#BillTypeFilter").val(),
            allowPart: (function () {
                var value = $("#AllowPartFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
			upper: $("#UpperFilter").val(),
			lower: $("#LowerFilter").val(),
			billsCountMin: $("#BillsCountFilterMin").val(),
			billsCountMax: $("#BillsCountFilterMax").val(),
			jOEBPPSTrx: $("#JOEBPPSTrxFilter").val(),
			processDateMin: $("#ProcessDateFilterMin").val(),
			processDateMax: $("#ProcessDateFilterMax").val(),
			sTMTDate: $("#STMTDateFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#MadfoatcomResponsesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(madfoatcomResponseService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Application.MadfoatcomResponses.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Application.MadfoatcomResponses.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    madfoatcomResponseService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "billerCode" },
			{ data: "billingNo" },
			{ data: "billNo" },
			{ data: "dueAmt" },
			{ data: "validationCode" },
			{ data: "serviceType" },
			{ data: "prepaidCat" },
			{ data: "amount" },
			{ data: "setBnkCode" },
			{ data: "acctNo" },
			{ data: "transferReason" },
			{ data: "receivingCountry" },
			{ data: "custName" },
			{ data: "email" },
			{ data: "phone" },
			{ data: "recCount" },
			{ data: "billStatus" },
			{ data: "dueAmount" },
            {
                data: "issueDate",
                render: function (issueDate) {
                    if (!issueDate) {
                        return "";
                    }
                    
					var date = Date.parse(issueDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
            {
                data: "openDate",
                render: function (openDate) {
                    if (!openDate) {
                        return "";
                    }
                    
					var date = Date.parse(openDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
            {
                data: "dueDate",
                render: function (dueDate) {
                    if (!dueDate) {
                        return "";
                    }
                    
					var date = Date.parse(dueDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
            {
                data: "expiryDate",
                render: function (expiryDate) {
                    if (!expiryDate) {
                        return "";
                    }
                    
					var date = Date.parse(expiryDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
            {
                data: "closeDate",
                render: function (closeDate) {
                    if (!closeDate) {
                        return "";
                    }
                    
					var date = Date.parse(closeDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "billType" },
            {
                data: "allowPart",
                render: function (allowPart) {
                    return allowPart ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
			{ data: "upper" },
			{ data: "lower" },
			{ data: "billsCount" },
			{ data: "jOEBPPSTrx" },
            {
                data: "processDate",
                render: function (processDate) {
                    if (!processDate) {
                        return "";
                    }
                    
					var date = Date.parse(processDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "sTMTDate" }
        ]
    }));
    
    //<suite-custom-code-block-2>
    //</suite-custom-code-block-2>

    createModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    editModal.onResult(function () {
        dataTable.ajax.reloadEx();;
    });

    $("#NewMadfoatcomResponseButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        madfoatcomResponseService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/madfoatcom-responses/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText },
                            { name: 'billerCodeMin', value: input.billerCodeMin },
                            { name: 'billerCodeMax', value: input.billerCodeMax }, 
                            { name: 'billingNo', value: input.billingNo }, 
                            { name: 'billNo', value: input.billNo }, 
                            { name: 'dueAmt', value: input.dueAmt }, 
                            { name: 'validationCode', value: input.validationCode }, 
                            { name: 'serviceType', value: input.serviceType }, 
                            { name: 'prepaidCat', value: input.prepaidCat }, 
                            { name: 'amount', value: input.amount },
                            { name: 'setBnkCodeMin', value: input.setBnkCodeMin },
                            { name: 'setBnkCodeMax', value: input.setBnkCodeMax }, 
                            { name: 'acctNo', value: input.acctNo }, 
                            { name: 'transferReason', value: input.transferReason }, 
                            { name: 'receivingCountry', value: input.receivingCountry }, 
                            { name: 'custName', value: input.custName }, 
                            { name: 'email', value: input.email }, 
                            { name: 'phone', value: input.phone },
                            { name: 'recCountMin', value: input.recCountMin },
                            { name: 'recCountMax', value: input.recCountMax }, 
                            { name: 'billStatus', value: input.billStatus }, 
                            { name: 'dueAmount', value: input.dueAmount },
                            { name: 'issueDateMin', value: input.issueDateMin },
                            { name: 'issueDateMax', value: input.issueDateMax },
                            { name: 'openDateMin', value: input.openDateMin },
                            { name: 'openDateMax', value: input.openDateMax },
                            { name: 'dueDateMin', value: input.dueDateMin },
                            { name: 'dueDateMax', value: input.dueDateMax },
                            { name: 'expiryDateMin', value: input.expiryDateMin },
                            { name: 'expiryDateMax', value: input.expiryDateMax },
                            { name: 'closeDateMin', value: input.closeDateMin },
                            { name: 'closeDateMax', value: input.closeDateMax }, 
                            { name: 'billType', value: input.billType }, 
                            { name: 'allowPart', value: input.allowPart }, 
                            { name: 'upper', value: input.upper }, 
                            { name: 'lower', value: input.lower },
                            { name: 'billsCountMin', value: input.billsCountMin },
                            { name: 'billsCountMax', value: input.billsCountMax }, 
                            { name: 'jOEBPPSTrx', value: input.jOEBPPSTrx },
                            { name: 'processDateMin', value: input.processDateMin },
                            { name: 'processDateMax', value: input.processDateMax }, 
                            { name: 'sTMTDate', value: input.sTMTDate }
                            ]);
                            
                    var downloadWindow = window.open(url, '_blank');
                    downloadWindow.focus();
            }
        )
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reloadEx();;
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reloadEx();;
    });
    
    //<suite-custom-code-block-3>
    //</suite-custom-code-block-3>
    
    
});
