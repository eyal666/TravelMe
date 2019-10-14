function initMap() {
    const url = 'https://localhost:44393/Places/GetPlacesJson';

    $.getJSON(url, (data, status) => {
        const mapElement = $('#map')[0];
        const center = { lat: data[0].Latitude, lng: data[0].Longtitude };
        const map = new google.maps.Map(mapElement, { zoom: 4, center: center });

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