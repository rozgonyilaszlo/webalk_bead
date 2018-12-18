$(document).ready(function () {
    $("#add-new-car").load("Car/Create");
    $("#cars-table").load("Car/List");

    $("#add-new-manufacturer").load("Manufacturer/Create");
    $("#manufacturers-table").load("Manufacturer/List");

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

    $(document).on("submit", "#add-new-manufacturer", function (event) {
        event.preventDefault();

        $.ajax({
            type: "POST",
            url: "Manufacturer/Create",
            data: $("#add-new-manufacturer form").serialize(),
            success: function (data) {
                $("#add-new-manufacturer").html(data);
                LoadManufacturers();
            },
            error: function (data) {
                $("#add-new-manufacturer").html(data);
            }
        });
    });

    $(document).on("click", "#manufacturers-table table tr", function (event) {
        var manufacturer = $(this).children()[0].innerHTML;
        document.cookie = "name=" + manufacturer;

        $.getJSON("Manufacturer/Cars", function (data) {
            var carNames = data.map(function (car) {
                return car.name;
            });

            alert(carNames);
        });
    });

    function LoadCars() {
        $("#cars-table").empty();
        $("#cars-table").load("Car/List");
    };

    function LoadManufacturers() {
        $("#manufacturers-table").empty();
        $("#manufacturers-table").load("Manufacturer/List");
    };
});