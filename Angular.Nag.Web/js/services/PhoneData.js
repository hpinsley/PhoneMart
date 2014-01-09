'use strict';

nagApp.factory('phoneData', function ($resource, $http, $q) {

    var planResource = $resource(nagApp.getServicesRoot() + "/api/plans/:id", { id: '@id' });
    var accountResource = $resource(nagApp.getServicesRoot() + "/api/accounts/:id", { id: '@id' });
    var appResource = $resource(nagApp.getServicesRoot() + "/api/apps/:id", { id: '@id' });
    var accountsResource = $resource(nagApp.getServicesRoot() + "/api/accounts");
    var manufacturersResource = $resource(nagApp.getServicesRoot() + "/api/manufacturers");
    var phoneInstanceResource = $resource(nagApp.getServicesRoot() + "/api/accounts/:accountId/phones/:phoneInstanceId", { accountId: '@accountId', phoneInstanceId: '@phoneInstanceId' });
    var phoneResource = $resource(nagApp.getServicesRoot() + "/api/phones/:phoneId", { phoneId: '@phoneId' });

    //Internal, generalized function to do a get and return a promise
    function getDataPromise(getUrl) {
        var deferred = $q.defer();
        $http({ method: "GET", url: getUrl })
            .success(function (data) {
                deferred.resolve(data);
            })
            .error(function (error) {
                deferred.reject(error);
            });

        return deferred.promise;
    }

    return {

        getAccount: function (accountId) {
            return accountResource.get({ id: accountId });
        },

        getAccounts: function () {
            return accountsResource.query();
        },

        getApp: function(appId, onSuccess) {
            return appResource.get({ id: appId },
                function(app) {
                    if (onSuccess) {
                        onSuccess(app);
                    }
                }
            );
        },

        getAccessories: function () {
            return getDataPromise(nagApp.getServicesRoot() + "/api/accessories");
        },

        getApps: function () {
            return getDataPromise(nagApp.getServicesRoot() + "/api/apps");
        },

        getManufacturers: function () {
            return manufacturersResource.query();
        },

        getPhone: function (phoneId) {
            var deferred = $q.defer();

            phoneResource.get({ phoneId: phoneId },
                function (phone) {
                    deferred.resolve(phone);
                },
                function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        },

        //Just to show how to do this without a resource and with $http       
        getPhones: function () {
            return getDataPromise(nagApp.getServicesRoot() + "/api/phones");
        },

        getPlan: function (planId, onSuccess) {
            return planResource.get({ id: planId },
                function (plan) {
                    if (onSuccess) {
                        onSuccess(plan);
                    }
                });
        },

        getPhoneInstance: function (accountId, phoneInstanceId, onSuccess) {
            return phoneInstanceResource.get({ accountId: accountId, phoneInstanceId: phoneInstanceId },
                function (phoneInstance) {
                    if (onSuccess) {
                        onSuccess(phoneInstance);
                    }
                });
        },

        //Just to show how to do this without a resource and with $http       
        getPlans: function () {
            return getDataPromise(nagApp.getServicesRoot() + "/api/plans");
        }
    };
});