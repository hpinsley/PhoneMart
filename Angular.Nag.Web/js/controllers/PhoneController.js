'use strict';

nagApp.controller('PhoneController',
    function PhoneController($scope, phoneData) {

        $scope.name = "Howard";
        $scope.phones = phoneData.getPhones();   //this is a promise that Angular knows how to bind to
        
        //When you pass the scoped object (which is a promise) back
        //into a controller method, Angular unwraps the real object for you.
        
        $scope.morePhones = function (phones) {
            var numPhones = phones.length + 1;
            phones.push({ model: "Phone " + numPhones, price: 10.00 * numPhones });
        };

        $scope.lessPhones = function(phones) {
            $scope.deletedPhone = phones.pop();
        };

        $scope.updateDescriptions = function(phones) {
            $.each(phones, function(i, phone) {
                phone.description = "Phone " + i;
                if (phone.price < 100) {
                    phone.description += "\n\nThis phone is under $100.00";
                }
            });
        };
        
        $scope.displayPhone = function(phone) {
            alert("Model: " + phone.model + "\n\n" + phone.description);
        };

    });
