//TODO: Add interactive map (on marker click)

let coordinates = {};

function setCoordinates(lat, lng) {
  coordinates.lat = parseFloat(lat);
  coordinates.lng = parseFloat(lng);
}

function initMultiMarkerMap() {
  const url = '/Places/GetAllPlaces';

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
    let markers = [];
    data.forEach(place => {
      const pos = { lat: place.Latitude, lng: place.Longtitude }
      const marker = new google.maps.Marker(
        {
          position: pos,
          map: map,
          title: place.Address,
          url: `PostDetails/Index/${place.PostsIdList.split(",")[0]}`
        }
      );
      marker.addListener('click', () => window.location.href = marker.url);
      markers.push(marker);
    });
    const markerCluster = new MarkerClusterer(map, markers, {
      styles: [{ height: 65, width: 66, url: 'Content/Photos/markercluster1.png' }]
    });
    
  });
}

function initSingleMarkerMap() {
  const map = makeMap(12, coordinates);
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

function setTemperatures() {
  let url = `//api.openweathermap.org/data/2.5/weather?lat=${coordinates.lat}&lon=${coordinates.lng}&units=metric&appid=cc0be754151c6d2a5897645cb8258f46`;
  $.get(url, (data, status) => {
    $('#tempurature').html(`Now: ${parseInt(data.main.temp)} °C`);
  });
}