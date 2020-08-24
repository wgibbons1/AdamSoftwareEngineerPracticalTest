$('#document').ready(function () {
    loadCommentsTable();

    $('#CreateCommentModal').on('show.bs.modal', function () {
        $('#CreateCommentForm')[0].reset();
    });

    $('#CreateCommentForm').submit(function (event) {
        event.preventDefault();
        $.blockUI();
        $.ajax({
            url: $('#CustomeCommentsPostUrl').val(),
            method: 'post',
            data: {
                customerId: $('#Customer_CustomerID').val(),
                comment: $('#CreateCommentForm [name=Comment]').val()
            }
        }).done(function () {
            loadCommentsTable();
            $.unblockUI();
            $('#CreateCommentModal').modal('hide');
        }).fail(function () {
            $.unblockUI();
            alert('Create comment failed');
        });
    });
});

function loadCommentsTable() {
    $('#Comments tbody').empty();

    $.ajax({
        url: $('#CustomersApiGetUrl').val(),
        data: {
            id: $('#Customer_CustomerID').val()
        }
    }).done(function (customer) {
        if (customer.customerComments.length === 0) {
            let tr = document.createElement('tr');

            let td = document.createElement('td');
            td.innerHTML = 'No records';
            tr.append(td);

            $('#Comments tbody').append(tr);
            return;
        }

        $.each(customer.customerComments, function (i, customerComment) {
            let tr = document.createElement('tr');

            let tdTimestamp = document.createElement('td');
            tdTimestamp.innerHTML = moment(customerComment.timeStamp).format('DD/MM/YYYY hh:mm');
            tr.append(tdTimestamp);

            let tdComment = document.createElement('td');
            tdComment.innerHTML = customerComment.comment;
            tr.append(tdComment);

            $('#Comments tbody').append(tr);
        });
    }).fail(function () {
        alert('Load comments table failed');
    });
}