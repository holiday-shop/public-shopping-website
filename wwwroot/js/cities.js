function renderCities(cities) {
    $('content').empty()

    $(cities).each(function(i, city) {
        elCity = $('<div class = "city">')
        elCity.append($('<h2>' + city.name + '</h2>' ));
        elCity.append($('<span class = "time">' + city.time + '</span>')); 

        $('content').append(elCity);
    });
} 

function requestCities() {
    $.getJSON({
        dataType: "json",
        url: "/Home/GetCities",
        success: renderCities
    });
}

function startCityLoadingLoop() {
    window.cityLoader = setInterval(requestCities, 1000);
}