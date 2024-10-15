$(function () {
    var l = abp.localization.getResource("Application");
	
	var orangeBillPaymentNotificationConfigurationService = window.application.orangeBillPaymentNotificationConfigurations.orangeBillPaymentNotificationConfigurations;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "OrangeBillPaymentNotificationConfigurations/CreateModal",
        scriptUrl: abp.appPath + "Pages/OrangeBillPaymentNotificationConfigurations/createModal.js",
        modalClass: "orangeBillPaymentNotificationConfigurationCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "OrangeBillPaymentNotificationConfigurations/EditModal",
        scriptUrl: abp.appPath + "Pages/OrangeBillPaymentNotificationConfigurations/editModal.js",
        modalClass: "orangeBillPaymentNotificationConfigurationEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            serviceTypeName: $("#ServiceTypeNameFilter").val(),
			configurationKey: $("#ConfigurationKeyFilter").val(),
			configurationValue: $("#ConfigurationValueFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#OrangeBillPaymentNotificationConfigurationsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(orangeBillPaymentNotificationConfigurationService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Application.OrangeBillPaymentNotificationConfigurations.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Application.OrangeBillPaymentNotificationConfigurations.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    orangeBillPaymentNotificationConfigurationService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "serviceTypeName" },
			{ data: "configurationKey" },
			{ data: "configurationValue" }
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

    $("#NewOrangeBillPaymentNotificationConfigurationButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        orangeBillPaymentNotificationConfigurationService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/orange-bill-payment-notification-configurations/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'serviceTypeName', value: input.serviceTypeName }, 
                            { name: 'configurationKey', value: input.configurationKey }, 
                            { name: 'configurationValue', value: input.configurationValue }
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
