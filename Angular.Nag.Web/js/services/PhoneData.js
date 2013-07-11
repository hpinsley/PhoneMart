'use strict';

nagApp.factory('phoneData', function ($http, $q) {
    return {
        getPhones: function () {

            var deferred = $q.defer();
            
            $http({
                    method: "GET",
                    url: "http://localhost/Angular.Nag.Services/api/phones"
                
                })
                .success(function(data, status, headers, config) {
                    deferred.resolve(data);
                })
                .error(function (data, status, headers, config) {
                    deferred.reject(status);
                });

            return deferred.promise;
        }
    };
});