'use strict';

nagApp.factory('phoneData', function ($resource, $http, $q) {

    var planResource = $resource(nagApp.getServicesRoot() + "/api/plans/:id", { id: '@id' });
    var accountResource = $resource(nagApp.getServicesRoot() + "/api/accounts/:id", { id: '@id' });
    var accountsResource = $resource(nagApp.getServicesRoot() + "/api/accounts");
    var manufacturersResource = $resource(nagApp.getServicesRoot() + "/api/manufacturers");

    return {

        getPlan: function(planId) {
            return planResource.get({ id: planId });
        },

        getAccount: function(accountId) {
            return accountResource.get({ id: accountId });
        },
        
        getAccounts: function () {
            return accountsResource.query();
        },

        getManufacturers: function() {
            return manufacturersResource.query();
        },

        //Just to show how to do this without a resource and with $http       
        getPhones: function () {
            var deferred = $q.defer();
            $http({ method: "GET", url: nagApp.getServicesRoot() + "/api/phones"})
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function(error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },

        //Just to show how to do this without a resource and with $http       
        getPlans: function () {
            var deferred = $q.defer();
            $http({ method: "GET", url: nagApp.getServicesRoot() + "/api/plans" })
                .success(function(data) {
                    deferred.resolve(data);
                })
                .error(function(error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }
    };
});