function initMap(places) {
    var map = L.map('map').setView([56.8796, 24.6032], 7);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '© OpenStreetMap contributors'
    }).addTo(map);

    places.forEach(function (place) {
        L.marker([place.coordinates.latitude, place.coordinates.longitude])
            .addTo(map)
            .bindPopup(place.name);
    });
}
