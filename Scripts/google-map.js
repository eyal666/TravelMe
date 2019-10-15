var coordinates = {};

function setCoordinates(lat, lng) {
    coordinates.lat = parseFloat(lat);
    coordinates.lng = parseFloat(lng);
}

function initMultiMarkerMap() {
    const url = 'https://localhost:44393/Places/GetAllPlaces';

    $.getJSON(url, (data, status) => {
        let avgLat = 0.0, avgLng = 0.0;

        //Calculate center
        data.forEach(place => {
            avgLat += place.Latitude;
            avgLng += place.Longtitude;
        });

        avgLat /= data.length;
        avgLng /= data.length;

        const map = makeMap(2, { lat: avgLat, lng: avgLng });

        data.forEach(place => {
            const pos = { lat: place.Latitude, lng: place.Longtitude }
            const marker = new google.maps.Marker(
                {
                    position: pos,
                    map: map,
                    title: place.Name
                }
            );
        });
    });
}

function initSingleMarkerMap() {
    const map = makeMap(7, coordinates);
    const marker = new google.maps.Marker(
        {
            position: coordinates,
            map: map
        }
    );
}

function makeMap(zoom, center) {
   return new google.maps.Map($('#map')[0], { zoom: zoom, center: center });
}