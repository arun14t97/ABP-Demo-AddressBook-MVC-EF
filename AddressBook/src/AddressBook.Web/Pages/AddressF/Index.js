$(function () {
    var l = abp.localization.getResource('AddressBook');
    var createModal = new abp.ModalManager(abp.appPath + 'AddressF/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'AddressF/EditModal');

    var dataTable = $('#AddressFTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(addressBook.addressF.address.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: 
                                        abp.auth.isGranted('AddressBook.AddressF.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: 
                                        abp.auth.isGranted('AddressBook.AddressF.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'AddressDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        addressBook.addressF.address
                                            .delete(data.record.id)
                                            .then(function() {
                                                abp.notify.info(
                                                    l('SuccessfullyDeleted')
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Street'),
                    data: "street"
                },
                {
                    title: l('City'),
                    data: "city",
                   
                },
                {
                    title: l('State'),
                    data: "state"
                },
                {
                    title: l('PostalCode'),
                    data: "postalCode"
                },
                {
                    title: l('Country'),
                    data: "country"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAddressButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
