window.antdesign = {
    tooltip: {
        poppers: {},
        create: function (tooltip, target, placement, key) {
            if (this.poppers[key] === undefined) {
                let popperInstance = Popper.createPopper(target, tooltip, {
                    placement: placement,
                    modifiers: {
                        flip: {
                            behavior: "flip"
                        },
                        //preventOverflow: {
                        //    boundary: "scrollParent"
                        //}
                    }
                });
                this.poppers[key] = popperInstance;
            } else {
                this.poppers[key].forceUpdate();
            };
        },
        destroy: function (key) {
            let popperInstance = this.poppers[key];
            if (popperInstance) {
                popperInstance.destroy();
                popperInstance = null
            }
            delete this.poppers[key]
        },
    }
}