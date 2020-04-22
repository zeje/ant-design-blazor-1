"use strict";

window.antdesign = {
    tooltip: {
        poppers: {},
        create: function create(tooltip, target, placement, key) {
            if (this.poppers[key] === undefined) {
                var popperInstance = Popper.createPopper(target, tooltip, {
                    placement: placement,
                    modifiers: {
                        flip: {
                            behavior: "flip"
                        }
                    }
                });
                this.poppers[key] = popperInstance;
            } else {
                this.poppers[key].forceUpdate();
            };
        },
        destroy: function destroy(key) {
            var popperInstance = this.poppers[key];
            if (popperInstance) {
                popperInstance.destroy();
                popperInstance = null;
            }
            delete this.poppers[key];
        }
    },
    clipboard: {
        copy: function copy(text) {
            try {
                navigator.clipboard.writeText(text);
            } catch (e) {
                console.error("Ant Design - Text could not be copied.");
                console.log(e);
            }
        }
    }
};

