'use strict';

nagApp.factory('phoneData', function ($resource, $http, $q) {

    var planResource = $resource("http://localhost/Angular.Nag.Services/api/plans/:id", { id: '@id' });
    var accountResource = $resource("http://localhost/Angular.Nag.Services/api/accounts/:id", { id: '@id' });

    return {

        getPlan: function(planId) {
            return planResource.get({ id: planId });
        },

        getAccount: function(accountId) {
            return accountResource.get({ id: accountId });
        },
        
        getAccounts: function() {
            var r = $resource("http://localhost/Angular.Nag.Services/api/accounts");
            return r.query();
        },
        
        //getPhones: function () {
        //    var r = $resource("http://localhost/Angular.Nag.Services/api/phones");
        //    return r.query();
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
        },

        getPlans: function() {
            var deferred = $q.defer();
            $http({ method: "GET", url: "http://localhost/Angular.Nag.Services/api/plans" })
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