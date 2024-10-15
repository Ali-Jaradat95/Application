$(function () {
    var l = abp.localization.getResource("Application");
	
	var apiRequestResponseLogService = window.application.apiRequestResponseLogs.apiRequestResponseLogs;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ApiRequestResponseLogs/CreateModal",
        scriptUrl: abp.appPath + "Pages/ApiRequestResponseLogs/createModal.js",
        modalClass: "apiRequestResponseLogCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "ApiRequestResponseLogs/EditModal",
        scriptUrl: abp.appPath + "Pages/ApiRequestResponseLogs/editModal.js",
        modalClass: "apiRequestResponseLogEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            requestUrl: $("#RequestUrlFilter").val(),
			requestMethod: $("#RequestMethodFilter").val(),
			requestHeaders: $("#RequestHeadersFilter").val(),
			requestBody: $("#RequestBodyFilter").val(),
			responseBody: $("#ResponseBodyFilter").val(),
			responseStatusCodeMin: $("#ResponseStatusCodeFilterMin").val(),
			responseStatusCodeMax: $("#ResponseStatusCodeFilterMax").val(),
			responseHeaders: $("#ResponseHeadersFilter").val(),
			durationMsMin: $("#DurationMsFilterMin").val(),
			durationMsMax: $("#DurationMsFilterMax").val(),
			createdAtMin: $("#CreatedAtFilterMin").val(),
			createdAtMax: $("#CreatedAtFilterMax").val(),
			correlationId: $("#CorrelationIdFilter").val(),
			ipAddress: $("#IpAddressFilter").val(),
			userId: $("#UserIdFilter").val(),
			errorDetails: $("#ErrorDetailsFilter").val(),
            isSuccessful: (function () {
                var value = $("#IsSuccessfulFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
			sourceSystem: $("#SourceSystemFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#ApiRequestResponseLogsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(apiRequestResponseLogService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Application.ApiRequestResponseLogs.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Application.ApiRequestResponseLogs.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    apiRequestResponseLogService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "requestUrl" },
			{ data: "requestMethod" },
			{ data: "requestHeaders" },
			{ data: "requestBody" },
			{ data: "responseBody" },
			{ data: "responseStatusCode" },
			{ data: "responseHeaders" },
			{ data: "durationMs" },
            {
                data: "createdAt",
                render: function (createdAt) {
                    if (!createdAt) {
                        return "";
                    }
                    
					var date = Date.parse(createdAt);
                    return (new Date(date)).toLocaleDateString(abp.localization.currentCulture.name);
                }
            },
			{ data: "correlationId" },
			{ data: "ipAddress" },
			{ data: "userId" },
			{ data: "errorDetails" },
            {
                data: "isSuccessful",
                render: function (isSuccessful) {
                    return isSuccessful ? '<i class="fa fa-check"></i>' : '<i class="fa fa-times"></i>';
                }
            },
			{ data: "sourceSystem" }
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

    $("#NewApiRequestResponseLogButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        apiRequestResponseLogService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/api-request-response-logs/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'requestUrl', value: input.requestUrl }, 
                            { name: 'requestMethod', value: input.requestMethod }, 
                            { name: 'requestHeaders', value: input.requestHeaders }, 
                            { name: 'requestBody', value: input.requestBody }, 
                            { name: 'responseBody', value: input.responseBody },
                            { name: 'responseStatusCodeMin', value: input.responseStatusCodeMin },
                            { name: 'responseStatusCodeMax', value: input.responseStatusCodeMax }, 
                            { name: 'responseHeaders', value: input.responseHeaders },
                            { name: 'durationMsMin', value: input.durationMsMin },
                            { name: 'durationMsMax', value: input.durationMsMax },
                            { name: 'createdAtMin', value: input.createdAtMin },
                            { name: 'createdAtMax', value: input.createdAtMax }, 
                            { name: 'correlationId', value: input.correlationId }, 
                            { name: 'ipAddress', value: input.ipAddress }, 
                            { name: 'userId', value: input.userId }, 
                            { name: 'errorDetails', value: input.errorDetails }, 
                            { name: 'isSuccessful', value: input.isSuccessful }, 
                            { name: 'sourceSystem', value: input.sourceSystem }
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
