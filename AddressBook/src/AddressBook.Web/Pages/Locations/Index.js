$(function () {
    var l = abp.localization.getResource('AddressBook');
    var createModal = new abp.ModalManager(abp.appPath + 'Locations/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Locations/EditModal');

    var dataTable = $('#LocationsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(addressBook.locations.location.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('LocationDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        addressBook.locations.location
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }

                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Address'),
                    data: "address",
                    render: function (data) {
                        return l('Enum:AddressLoco.' + data);
                    }
                },
                {
                    title: l('Latitude'),
                    data: "latitude",
                    
                },
                {
                    title: l('Longitude'),
                    data: "longitude"
                },
                
            ]
        })
    );
   

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });
    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewLocationButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });

});
