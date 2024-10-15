$(function () {
    var l = abp.localization.getResource("Application");
	
	var emailRecipientSendingStatusLookupService = window.application.emailRecipientSendingStatusLookups.emailRecipientSendingStatusLookups;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "EmailRecipientSendingStatusLookups/CreateModal",
        scriptUrl: abp.appPath + "Pages/EmailRecipientSendingStatusLookups/createModal.js",
        modalClass: "emailRecipientSendingStatusLookupCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "EmailRecipientSendingStatusLookups/EditModal",
        scriptUrl: abp.appPath + "Pages/EmailRecipientSendingStatusLookups/editModal.js",
        modalClass: "emailRecipientSendingStatusLookupEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            code: $("#CodeFilter").val(),
			name: $("#NameFilter").val(),
			description: $("#DescriptionFilter").val()
        };
    };
    
    //<suite-custom-code-block-1>
    //</suite-custom-code-block-1>

    var dataTable = $("#EmailRecipientSendingStatusLookupsTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: true,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(emailRecipientSendingStatusLookupService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Application.EmailRecipientSendingStatusLookups.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Application.EmailRecipientSendingStatusLookups.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    emailRecipientSendingStatusLookupService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reloadEx();;
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "code" },
			{ data: "name" },
			{ data: "description" }
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

    $("#NewEmailRecipientSendingStatusLookupButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reloadEx();;
    });

    $("#ExportToExcelButton").click(function (e) {
        e.preventDefault();

        emailRecipientSendingStatusLookupService.getDownloadToken().then(
            function(result){
                    var input = getFilter();
                    var url =  abp.appPath + 'api/app/email-recipient-sending-status-lookups/as-excel-file' + 
                        abp.utils.buildQueryString([
                            { name: 'downloadToken', value: result.token },
                            { name: 'filterText', value: input.filterText }, 
                            { name: 'code', value: input.code }, 
                            { name: 'name', value: input.name }, 
                            { name: 'description', value: input.description }
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
