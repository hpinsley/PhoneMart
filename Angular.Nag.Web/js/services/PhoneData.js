'use strict';

nagApp.factory('phoneData', function ($http, $log) {
    return {
        getPhones: function(success) {
            $http({
                    method: "GET",
                    url: "http://localhost/Angular.Nag.Services/api/phones"
                
                })
                .success(function(data, status, headers, config) {
                    success(data);
                })
                .error(function (data, status, headers, config) {
                    $log.warn(data, status, headers, config);
                });


        }
    };
});