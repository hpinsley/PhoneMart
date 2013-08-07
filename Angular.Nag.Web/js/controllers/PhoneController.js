'use strict';

nagApp.controller('PhoneController', function PhoneController($scope, phoneData, $location) {

    //Private function to set the current phone on the root scope so 
    //that we remember it as we navigate the site.
    function setCurrentPhone(phone) {
        $scope.$root.currentPhone = phone;
    };
    
    function clearCurrentPhone() {
        $scope.$root.currentPhone = null;
    }
    
    $scope.phones = phoneData.getPhones(); //this is a promise that Angular knows how to bind to
    $scope.manufacturers = phoneData.getManufacturers();
    $scope.filters = {};

    //After the phones load, set a current phone to the first phone
    //if one is not already set.  Note that we set it on the root scope
    //but can test existence on our scope since we the scope inherits from
    //the root scope.  $scope.phones is a promise.
    
    $scope.phones.then(function(phones) {
        if (!$scope.currentPhone && phones.length > 0) {
            setCurrentPhone(phones[0]);
        }
    });

    //When a new phone is selected, remember it by setting the "current phone"
    $scope.selectPhone = function (phone) {
        setCurrentPhone(phone);
    };

    //When you pass the scoped object (which is a promise) back
    //into a controller method, Angular unwraps the real object for you.

    $scope.addPhone = function () {
        $location.path("/phones/add");
    };

    $scope.manufacturerSelected = function() {
        var manufacturer = $scope.selectedManufacturer;
        if (!manufacturer)
            return;
        console.log("You selected " + manufacturer);

        //If we are filtering, we want to select the first phone.
        //Unfortunately, the phones are filtering but the first phone
        //is not selecting.
        
        clearCurrentPhone();
        
        if (manufacturer == -1) {
            $scope.filters = {};
        } else {
            $scope.filters["manufacturer.manufacturerId"] = manufacturer;
            console.log($scope.filters);
        }
    };


});
