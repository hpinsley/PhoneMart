'use strict';

nagApp.factory('phoneData', function ($resource, $http, $q) {
    return {
        
        //getPhones: function () {
        //    var r = $resource("http://localhost/Angular.Nag.Services/api/phones");
        //    return r.get();
        //}
        
        getPhones: function() {
            var deferred = $q.defer();
            $http({ method: "GET", url:"http://localhost/Angular.Nag.Services/api/phones"})
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function(error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    };
});