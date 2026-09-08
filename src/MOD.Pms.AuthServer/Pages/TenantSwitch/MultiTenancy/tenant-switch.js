(function($) {
    var tenantSwitchModal = new abp.ModalManager(abp.appPath + 'TenantSwitch/MultiTenancy/TenantSwitchModal');
    $(function() {
        $('#TenantSwitchLink').click(function (e) {
             e.preventDefault();
            tenantSwitchModal.open();
        });

        tenantSwitchModal.onResult(function() {
            location.assign(location.href);
        });
    });

})(jQuery);