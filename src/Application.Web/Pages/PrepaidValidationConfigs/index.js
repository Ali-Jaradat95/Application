$(function () {
    var l = abp.localization.getResource("Application");
	
	var prepaidValidationConfigService = window.application.prepaidValidationConfigs.prepaidValidationConfigs;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "PrepaidValidationConfigs/CreateModal",
        scriptUrl: abp.appPath + "Pages/PrepaidValidationConfigs/createModal.js",
        modalClass: "prepaidValidationConfigCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "PrepaidValidationConfigs/EditModal",
        scriptUrl: abp.appPath + "Pages/PrepaidValidationConfigs/editModal.js",
        modalClass: "prepaidValidationConfigEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            serviceType: $("#ServiceTypeFilter").val(),
			channelCode: $("#ChannelCodeFilter").val(),
			billingName: $("#BillingNameFilter").val(),
			aliasBillingName: $("#AliasBillingNameFilter").val(),
            isTesting: (function () {
                var value = $("#IsTestingFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
			endpointUrl: $("#EndpointUrlFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#PrepaidValidationConfigsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(prepaidValidationConfigService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Application.PrepaidValidationConfigs.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Application.PrepaidValidationConfigs.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    prepaidValidationConfigService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "serviceType" },
			{ data: "channelCode" },
			{ data: "billingName" },
			{ data: "aliasBillingName" },
            {
                data: "isTesting",
                render: function (isTesting) {
                    return isTesting ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
			{ data: "endpointUrl" }
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

    $("#NewPrepaidValidationConfigButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        prepaidValidationConfigService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/prepaid-validation-configs/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'serviceType', value: input.serviceType }, 
                            { name: 'channelCode', value: input.channelCode }, 
                            { name: 'billingName', value: input.billingName }, 
                            { name: 'aliasBillingName', value: input.aliasBillingName }, 
                            { name: 'isTesting', value: input.isTesting }, 
                            { name: 'endpointUrl', value: input.endpointUrl }
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
