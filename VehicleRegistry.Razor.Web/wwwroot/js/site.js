$(document).ready(function () {
    $("#add-new-car").load("Car/Create");

    $("#cars-table").load("Car/List");

    $(document).on("submit", "#add-new-car", function (event) {
        event.preventDefault();

        $.ajax({
            type: "POST",
            url: "Car/Create",
            data: $("#add-new-car form").serialize(),
            success: function (data) {
                $("#add-new-car").html(data);
                LoadCars();
            },
            error: function (data) {
                $("#add-new-car").html(data);
            }
        });
    });

    function LoadCars() {
        $("#cars-table").empty();

        $("#cars-table").load("Car/List");
    };
});