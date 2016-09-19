
var map = null;

function GetMap() {

    map = new Microsoft.Maps.Map(document.getElementById("mapDiv"),
        {
            credentials: "AryzS-OoHizuNhXuWNXAExZuvxCtUpcCwpm6Kq21r3MBqJzLVDJJw_d60vtsTg47",
            zoom: 9
        });

    $.ajax({
        type: 'get',
        dataType: 'json',
        cache: false,
        url: "/Places/GetLocations",
        data: {},
        success: function (response) {
            setPushPinslayer(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {
        }
    });

    getCurrentLocation;

    Microsoft.Maps.Events.addHandler(map, 'click',  mapclick);
}


function setPushPinslayer(Places) {
    var pins= [];
    var loc;
    var p = Places.Locations;

    $.each(p, function (index, pin) {
        loc = new Microsoft.Maps.Location(pin.Latitude, pin.Longitude);
        pin = new Microsoft.Maps.Pushpin(loc, { color: 'red' });
        pin.customid = pin.PlaceId;
        pins.push(pin);

    });

    Microsoft.Maps.loadModule("Microsoft.Maps.Clustering", function () {
        var clusterLayer = new Microsoft.Maps.ClusterLayer(pins);
        map.layers.insert(clusterLayer);
        clusterLayer.setPushpins(pins);
    });
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

    var point = new Microsoft.Maps.Location(Lat, Long);
    var pin = new Microsoft.Maps.Pushpin(point, { color: 'red' });

    //Add the pushpin to the map
    map.entities.push(pin);
}
