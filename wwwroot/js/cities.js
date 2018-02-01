function renderCities(cities) {
    $('content').empty()

    $(cities).each(function(i, city) {
        elCity = $('<div class = "city">')
        elCity.text = city.name + " " + city.time

        $('content').append(city);
    });
}

function loadCities() {
    $.getJSON({
        dataType: "json",
        url: "/Home/GetCities",
        success: renderCities
    });
}

function startCityLoadingLoop() {
    window.cityLoader = setInterval(requestCities, 5);
}