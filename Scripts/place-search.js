let autocomplete;

function initAutocomplete() {
  // Create the autocomplete object, restricting the search predictions to
  // geographical location types.
  autocomplete = new google.maps.places.Autocomplete(
    $("#place-search")[0], { types: ['geocode', 'establishment'] });

  // Avoid paying for data that you don't need by restricting the set of
  // place fields that are returned to just the address components.
  autocomplete.setFields(['geometry', 'photos']);

  // When the user selects an address from the drop-down, populate the
  // address fields in the form.
  autocomplete.addListener('place_changed', fillInAddress);
}

function fillInAddress() {
  // Get the place details from the autocomplete object.
  const place = autocomplete.getPlace();
  $("#latitude")[0].value = place.geometry.location.lat();
  $("#longtitude")[0].value = place.geometry.location.lng();
  const imageUrl = place.photos[0].getUrl();
  $('#image-url')[0].value = imageUrl;
  $('#img-box')[0].src = imageUrl;
}
