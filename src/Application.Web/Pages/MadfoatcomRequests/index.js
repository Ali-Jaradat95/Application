$(function () {
    var l = abp.localization.getResource("Application");
	
	var madfoatcomRequestService = window.application.madfoatcomRequests.madfoatcomRequests;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "MadfoatcomRequests/CreateModal",
        scriptUrl: abp.appPath + "Pages/MadfoatcomRequests/createModal.js",
        modalClass: "madfoatcomRequestCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "MadfoatcomRequests/EditModal",
        scriptUrl: abp.appPath + "Pages/MadfoatcomRequests/editModal.js",
        modalClass: "madfoatcomRequestEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            billerCodeMin: $("#BillerCodeFilterMin").val(),
			billerCodeMax: $("#BillerCodeFilterMax").val(),
			billingNo: $("#BillingNoFilter").val(),
			billNo: $("#BillNoFilter").val(),
			serviceType: $("#ServiceTypeFilter").val(),
			prepaidCat: $("#PrepaidCatFilter").val(),
			dueAmtMin: $("#DueAmtFilterMin").val(),
			dueAmtMax: $("#DueAmtFilterMax").val(),
			validationCode: $("#ValidationCodeFilter").val(),
			jOEBPPSTrx: $("#JOEBPPSTrxFilter").val(),
			bankTrxId: $("#BankTrxIdFilter").val(),
			bankCode: $("#BankCodeFilter").val(),
			pmtStatus: $("#PmtStatusFilter").val(),
			paidAmtMin: $("#PaidAmtFilterMin").val(),
			paidAmtMax: $("#PaidAmtFilterMax").val(),
			feesAmtMin: $("#FeesAmtFilterMin").val(),
			feesAmtMax: $("#FeesAmtFilterMax").val(),
            feesOnBiller: (function () {
                var value = $("#FeesOnBillerFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
			processDateMin: $("#ProcessDateFilterMin").val(),
			processDateMax: $("#ProcessDateFilterMax").val(),
			stmtDateMin: $("#StmtDateFilterMin").val(),
			stmtDateMax: $("#StmtDateFilterMax").val(),
			accessChannel: $("#AccessChannelFilter").val(),
			paymentMethod: $("#PaymentMethodFilter").val(),
			paymentType: $("#PaymentTypeFilter").val(),
			amountMin: $("#AmountFilterMin").val(),
			amountMax: $("#AmountFilterMax").val(),
			setBnkCodeMin: $("#SetBnkCodeFilterMin").val(),
			setBnkCodeMax: $("#SetBnkCodeFilterMax").val(),
			acctNo: $("#AcctNoFilter").val(),
			name: $("#NameFilter").val(),
			phone: $("#PhoneFilter").val(),
			address: $("#AddressFilter").val(),
			email: $("#EmailFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#MadfoatcomRequestsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(madfoatcomRequestService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Application.MadfoatcomRequests.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Application.MadfoatcomRequests.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    madfoatcomRequestService.delete(data.record.id)
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
			{ data: "serviceType" },
			{ data: "prepaidCat" },
			{ data: "dueAmt" },
			{ data: "validationCode" },
			{ data: "jOEBPPSTrx" },
			{ data: "bankTrxId" },
			{ data: "bankCode" },
			{ data: "pmtStatus" },
			{ data: "paidAmt" },
			{ data: "feesAmt" },
            {
                data: "feesOnBiller",
                render: function (feesOnBiller) {
                    return feesOnBiller ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
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
            {
                data: "stmtDate",
                render: function (stmtDate) {
                    if (!stmtDate) {
                        return "";
                    }
                    
					var date = Date.parse(stmtDate);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "accessChannel" },
			{ data: "paymentMethod" },
			{ data: "paymentType" },
			{ data: "amount" },
			{ data: "setBnkCode" },
			{ data: "acctNo" },
			{ data: "name" },
			{ data: "phone" },
			{ data: "address" },
			{ data: "email" }
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

    $("#NewMadfoatcomRequestButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        madfoatcomRequestService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/madfoatcom-requests/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText },
                            { name: 'billerCodeMin', value: input.billerCodeMin },
                            { name: 'billerCodeMax', value: input.billerCodeMax }, 
                            { name: 'billingNo', value: input.billingNo }, 
                            { name: 'billNo', value: input.billNo }, 
                            { name: 'serviceType', value: input.serviceType }, 
                            { name: 'prepaidCat', value: input.prepaidCat },
                            { name: 'dueAmtMin', value: input.dueAmtMin },
                            { name: 'dueAmtMax', value: input.dueAmtMax }, 
                            { name: 'validationCode', value: input.validationCode }, 
                            { name: 'jOEBPPSTrx', value: input.jOEBPPSTrx }, 
                            { name: 'bankTrxId', value: input.bankTrxId }, 
                            { name: 'bankCode', value: input.bankCode }, 
                            { name: 'pmtStatus', value: input.pmtStatus },
                            { name: 'paidAmtMin', value: input.paidAmtMin },
                            { name: 'paidAmtMax', value: input.paidAmtMax },
                            { name: 'feesAmtMin', value: input.feesAmtMin },
                            { name: 'feesAmtMax', value: input.feesAmtMax }, 
                            { name: 'feesOnBiller', value: input.feesOnBiller },
                            { name: 'processDateMin', value: input.processDateMin },
                            { name: 'processDateMax', value: input.processDateMax },
                            { name: 'stmtDateMin', value: input.stmtDateMin },
                            { name: 'stmtDateMax', value: input.stmtDateMax }, 
                            { name: 'accessChannel', value: input.accessChannel }, 
                            { name: 'paymentMethod', value: input.paymentMethod }, 
                            { name: 'paymentType', value: input.paymentType },
                            { name: 'amountMin', value: input.amountMin },
                            { name: 'amountMax', value: input.amountMax },
                            { name: 'setBnkCodeMin', value: input.setBnkCodeMin },
                            { name: 'setBnkCodeMax', value: input.setBnkCodeMax }, 
                            { name: 'acctNo', value: input.acctNo }, 
                            { name: 'name', value: input.name }, 
                            { name: 'phone', value: input.phone }, 
                            { name: 'address', value: input.address }, 
                            { name: 'email', value: input.email }
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
