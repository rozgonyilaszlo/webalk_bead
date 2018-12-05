$(document).ready(function(){
    $("#home").on("click", function () {
        open("/", "_self");
    });

    $("#add-car").on("click", function () {
        $("#body").load("/home/car");
        LoadManufacturerNames();
        LoadCars();
    });

    $("#add-manufacturer").on("click", function () {
        $("#body").load("home/manufacturer");
        LoadManufacturers();
    });

    $(document).on("submit", "#add-new-car", function(event) {
        event.preventDefault();

        $.ajax({
            type: "POST",
            url: "home/addCar",
            data: $("#add-new-car form").serialize(),
            success: function(data){
                $("#add-new-car form").trigger("reset");
                LoadCars();
            },
            error: function () {
                alert("Something went wrong.");
            }
        });
    });

    $(document).on("submit", "#add-new-manufacturer", function(event) {
        event.preventDefault();

        $.ajax({
            type: "POST",
            url: "home/addManufacturers",
            data: $("#add-new-manufacturer form").serialize(),
            success: function(data){
                $("#add-new-manufacturer form").trigger("reset");
                LoadManufacturers();
            },
            error: function () {
                alert("Something went wrong.");
            }
        });
    });


    $(document).on("click", "tr .manufacturer-name", function (event) {
        var manufacturer = $(this).html();
        document.cookie="name="+manufacturer;

        $.getJSON("home/manufacturercookie", function (data) {
            var carNames = data.map(function(car){
                return car.name;
            });

            alert(carNames);
        });
    });

    function LoadCars() {
        $("#cars").empty();

        $.getJSON("home/cars", function (data) {
            $.each(data,  function (key, value) {
                var row = $("<tr id='"+ key + "'></tr>");
                var name = $("<td>" + value.name + "</td>");
                var consumption = $("<td>" + value.consumption + "</td>");
                var color = $("<td>" + value.color + "</td>");
                var manufacturer = $("<td>" + value.manufacturer + "</td>");
                var available = $("<td>" + value.available + "</td>");
                var year = $("<td>" + value.year + "</td>");
                var horsepower = $("<td>" + value.horsepower + "</td>");
                row.append(name);
                row.append(consumption);
                row.append(color);
                row.append(manufacturer);
                row.append(available);
                row.append(year);
                row.append(horsepower);
                $("#cars").append(row);
            });
        });
    };

    function LoadManufacturers() {
        $("#manufacturers").empty();

        $.getJSON("home/manufacturers", function (data) {
            $.each(data,  function (key, value) {
               var row = $("<tr id='"+ key + "'></tr>");
               var name = $("<td class='manufacturer-name'>" + value.name + "</td>");
               var country = $("<td>" + value.country + "</td>");
               //https://flaviocopes.com/javascript-dates/
               var founded = $("<td>" + new Intl.DateTimeFormat().format(new Date(value.founded)) + "</td>");
               row.append(name);
               row.append(country);
               row.append(founded);
               $("#manufacturers").append(row);
            });
        });
    };

    function LoadManufacturerNames() {
        $("#manufacturer-selector").empty();

        $.getJSON("home/manufacturerNames", function (data) {
            $.each(data, function (key, value) {
                $("#manufacturer-selector").append("<option value='" + value + "'>" + value + "</option>");
            });
        });
    };
});