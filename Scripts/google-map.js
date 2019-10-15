function initMap() {
    const url = 'https://localhost:44393/Places/GetPlacesJson';

    $.getJSON(url, (data, status) => {
        const mapElement = $('#map')[0];
        let avgLat = 0.0, avgLng = 0.0;

        //Calculate center
        data.forEach(place => {
            avgLat += place.Latitude;
            avgLng += place.Longtitude;
        });

        avgLat /= data.length;
        avgLng /= data.length;

        const map = new google.maps.Map(mapElement, { zoom: 2, center: { lat: avgLat, lng: avgLng }});

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