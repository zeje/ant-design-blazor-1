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
    },
    clipboard: {
        copy: function (text) {
            try {
                navigator.clipboard.writeText(text);
            } catch (e) {
                console.error("Ant Design - Text could not be copied.");
                console.log(e);
            }
        }
    }
}