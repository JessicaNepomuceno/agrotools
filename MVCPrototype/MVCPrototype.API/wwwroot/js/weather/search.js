const weather_container = $("#weather-list");
const ICON_SRC = "/icons";

$(document).ready(function () {
    $("#weather-search").click(function () {
        $("#weather-alert").empty();
        var startDate = $("#startDate").val();
        var endDate = $("#endDate").val();

        if (!startDate || !endDate) {
            alert("Por favor, preencha ambas as datas antes de pesquisar!");            
            return;
        }

        $.ajax({
            url: "/Weather/Search", 
            method: "GET",
            data: { startDate: startDate, endDate: endDate },
            success: function (response) {                
                if (!response[0]?.date) {
                    alert("Por favor, verifique as datas informadas e tente novamente!");
                    return;
                } else {
                    weather_container.empty();
                    response.forEach((weather) => {
                        weather_container[0].append(mountWeatherDisplay(weather));
                    });
                }
            },            
        });
    });
});

function mountWeatherDisplay(weather_object) {
    let weather = document.createElement("DIV");
    weather.classList.add("weather-display");

    let header = document.createElement("SPAN");
    header.innerText = `${weather_object.date}`;

    let footer = document.createElement("SPAN");
    footer.innerText = weather_object.summary;

    let temperature = document.createElement("SPAN");
    temperature.classList.add("weather-temperature");
    temperature.innerText = `${weather_object.temperatureC}`;

    let icon = document.createElement("LABEL");
    icon.appendChild(getIcon(weather_object.summary));    

    weather.appendChild(header);
    weather.appendChild(temperature);
    weather.appendChild(icon);
    weather.appendChild(footer);

    return weather;
}

function getIcon(summary) {
    const icon_img = document.createElement("IMG");
    switch (summary) {
        case "Frio":
            icon_img.src = ICON_SRC + "/snowflake-solid.svg";
            break;
        case "Nublado":
            icon_img.src = ICON_SRC + "/smog-solid.svg";
            break;
        case "Ensolarado":
            icon_img.src = ICON_SRC + "/sun-solid.svg";
            break;
        case "Chuvoso":
            icon_img.src = ICON_SRC + "/rain-solid.svg";
            break;
    }
    return icon_img;
}

function sendWeatherAlert(message) {
    let weatherAlert = document.createElement("P");
    weatherAlert.innerText = `${message}`;    
    return weather;
}