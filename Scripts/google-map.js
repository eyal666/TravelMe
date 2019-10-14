function initMap() {

    var map = new google.maps.Map(
        document.getElementById('map'), { zoom: 4, center: locations[0] });

    var url = 'https://localhost:44393/Places/GetPlacesJson'
    $.getJSON(url, function (data, status) {
        for (var i = 0; i < data.length; i++) {
            var pos = { lat: data[i].Latitude, lng: data[i].Longtitude }
            var marker = new google.maps.Marker(
                {
                    position: pos,
                    map: map,
                    title: data[i].Name
                }
            );
        }
    });
}