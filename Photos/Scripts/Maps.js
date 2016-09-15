
var map = null;
var loc = null;

function GetMap() {
    map = new Microsoft.Maps.Map(document.getElementById("mapDiv"), 
        { credentials: "AryzS-OoHizuNhXuWNXAExZuvxCtUpcCwpm6Kq21r3MBqJzLVDJJw_d60vtsTg47", 
         zoom: 9 });

    pinPlaces;
    getCurrentLocation;

    Microsoft.Maps.Events.addHandler(map, 'click',  mapclick);
    }

function pinPlaces() {
    $.getJSON("/Places/GetLocations", function(result){
        $.each(result.Items, function (index, item) {
                                pushpin(item.Latitude, item.Longitude);
        })});
}

function getCurrentLocation() {
    var geoLocationProvider = new Microsoft.Maps.GeoLocationProvider(map);
    geoLocationProvider.getCurrentPosition();
}

function mapclick(e) {
        var point = new Microsoft.Maps.Point(e.getX(), e.getY());
        loc = e.target.tryPixelToLocation(point);

        document.getElementById('Latitude').innerText = loc.latitude;
        document.getElementById('Longitude').innerText = loc.longitude;
        Microsoft.Maps.loadModule('Microsoft.Maps.Search', { callback: searchModuleLoaded });
    }
function searchModuleLoaded() {
    var searchManager = new Microsoft.Maps.Search.SearchManager(map);

    var reverseGeocodeRequest = { location: new Microsoft.Maps.Location(loc.latitude, loc.longitude), count: 10, callback: reverseGeocodeCallback, errorCallback: errCallback };
    searchManager.reverseGeocode(reverseGeocodeRequest);
}

function reverseGeocodeCallback(result, userData) {
    var r = result.name.split(",");
    document.getElementById('Placename').innerText = r[1];
}

function errCallback(request) {
    alert("An error occurred.");
}

function pushpin(Lat, Long) {
    var pushpinOptions = { icon: '/images/Map-Marker-Push-Pin-2-Left-Chartreuse-icon.png', width: 48, height: 48 };

    var point = new Microsoft.Maps.Location(Lat, Long);
    var pin = new Microsoft.Maps.Pushpin(point, pushpinOptions);
    

    //Add the pushpin to the map
    map.entities.push(pin);
}
