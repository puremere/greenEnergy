$(document).ready(function () {
    $('#ajax-form').submit(function (e) {
        e.preventDefault(); // Prevent the default form submission
        var formData = $(this).serialize(); // Serialize the form data
        // Make an AJAX request
        $.ajax({
            type: 'POST',
            url: $(this).attr('action'),
            data: formData,
            dataType: 'json',
            success: function (response) {
                var resultElement = $('#result');
                if (response.status === 'success') {
                    resultElement.html(response.message).removeClass('text-red-500 text-gray-400').addClass('text-green-500');
                } else {
                    resultElement.html(response.message).removeClass('text-green-500 text-gray-400').addClass('text-red-500');
                }
            },
            error: function () {
                $('#result').html('An error occurred. Please try again.').removeClass('text-green-500 text-gray-400').addClass('text-red-500');
            }
        });
    });
});
