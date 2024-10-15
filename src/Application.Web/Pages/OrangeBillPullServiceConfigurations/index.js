$(function () {
    var l = abp.localization.getResource("Application");
	
	var orangeBillPullServiceConfigurationService = window.application.orangeBillPullServiceConfigurations.orangeBillPullServiceConfigurations;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "OrangeBillPullServiceConfigurations/CreateModal",
        scriptUrl: abp.appPath + "Pages/OrangeBillPullServiceConfigurations/createModal.js",
        modalClass: "orangeBillPullServiceConfigurationCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "OrangeBillPullServiceConfigurations/EditModal",
        scriptUrl: abp.appPath + "Pages/OrangeBillPullServiceConfigurations/editModal.js",
        modalClass: "orangeBillPullServiceConfigurationEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            serviceTypeIdMin: $("#ServiceTypeIdFilterMin").val(),
			serviceTypeIdMax: $("#ServiceTypeIdFilterMax").val(),
            isServiceEnabled: (function () {
                var value = $("#IsServiceEnabledFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
            isWebServiceEnabled: (function () {
                var value = $("#IsWebServiceEnabledFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
			webServiceUrl: $("#WebServiceUrlFilter").val(),
			storedProcedureName: $("#StoredProcedureNameFilter").val(),
			billerCode: $("#BillerCodeFilter").val(),
			connectionStringUserId: $("#ConnectionStringUserIdFilter").val(),
			connectionStringPassword: $("#ConnectionStringPasswordFilter").val(),
			connectionStringDataSource: $("#ConnectionStringDataSourceFilter").val(),
			logLevel: $("#LogLevelFilter").val(),
			severityIdMin: $("#SeverityIdFilterMin").val(),
			severityIdMax: $("#SeverityIdFilterMax").val(),
			dailyLimitMin: $("#DailyLimitFilterMin").val(),
			dailyLimitMax: $("#DailyLimitFilterMax").val(),
			weeklyLimitMin: $("#WeeklyLimitFilterMin").val(),
			weeklyLimitMax: $("#WeeklyLimitFilterMax").val(),
			monthlyLimitMin: $("#MonthlyLimitFilterMin").val(),
			monthlyLimitMax: $("#MonthlyLimitFilterMax").val(),
			yearlyLimitMin: $("#YearlyLimitFilterMin").val(),
			yearlyLimitMax: $("#YearlyLimitFilterMax").val(),
			errorMessage: $("#ErrorMessageFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#OrangeBillPullServiceConfigurationsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(orangeBillPullServiceConfigurationService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Application.OrangeBillPullServiceConfigurations.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Application.OrangeBillPullServiceConfigurations.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    orangeBillPullServiceConfigurationService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "serviceTypeId" },
            {
                data: "isServiceEnabled",
                render: function (isServiceEnabled) {
                    return isServiceEnabled ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
            {
                data: "isWebServiceEnabled",
                render: function (isWebServiceEnabled) {
                    return isWebServiceEnabled ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
			{ data: "webServiceUrl" },
			{ data: "storedProcedureName" },
			{ data: "billerCode" },
			{ data: "connectionStringUserId" },
			{ data: "connectionStringPassword" },
			{ data: "connectionStringDataSource" },
			{ data: "logLevel" },
			{ data: "severityId" },
			{ data: "dailyLimit" },
			{ data: "weeklyLimit" },
			{ data: "monthlyLimit" },
			{ data: "yearlyLimit" },
			{ data: "errorMessage" }
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

    $("#NewOrangeBillPullServiceConfigurationButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        orangeBillPullServiceConfigurationService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/orange-bill-pull-service-configurations/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText },
                            { name: 'serviceTypeIdMin', value: input.serviceTypeIdMin },
                            { name: 'serviceTypeIdMax', value: input.serviceTypeIdMax }, 
                            { name: 'isServiceEnabled', value: input.isServiceEnabled }, 
                            { name: 'isWebServiceEnabled', value: input.isWebServiceEnabled }, 
                            { name: 'webServiceUrl', value: input.webServiceUrl }, 
                            { name: 'storedProcedureName', value: input.storedProcedureName }, 
                            { name: 'billerCode', value: input.billerCode }, 
                            { name: 'connectionStringUserId', value: input.connectionStringUserId }, 
                            { name: 'connectionStringPassword', value: input.connectionStringPassword }, 
                            { name: 'connectionStringDataSource', value: input.connectionStringDataSource }, 
                            { name: 'logLevel', value: input.logLevel },
                            { name: 'severityIdMin', value: input.severityIdMin },
                            { name: 'severityIdMax', value: input.severityIdMax },
                            { name: 'dailyLimitMin', value: input.dailyLimitMin },
                            { name: 'dailyLimitMax', value: input.dailyLimitMax },
                            { name: 'weeklyLimitMin', value: input.weeklyLimitMin },
                            { name: 'weeklyLimitMax', value: input.weeklyLimitMax },
                            { name: 'monthlyLimitMin', value: input.monthlyLimitMin },
                            { name: 'monthlyLimitMax', value: input.monthlyLimitMax },
                            { name: 'yearlyLimitMin', value: input.yearlyLimitMin },
                            { name: 'yearlyLimitMax', value: input.yearlyLimitMax }, 
                            { name: 'errorMessage', value: input.errorMessage }
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
