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
    },
    window: {
        getDimensions: function () {
            return {
                width: window.innerWidth,
                height: window.innerHeight
            };
        },
        registerOnResizeHandler: function (reference) {
            const debounce = (func, wait, immediate) => {
                var timeout;
                return () => {
                    const context = this, args = arguments;
                    const later = function () {
                        timeout = null;
                        if (!immediate) func.apply(context, args);
                    };
                    const callNow = immediate && !timeout;
                    clearTimeout(timeout);
                    timeout = setTimeout(later, wait);
                    if (callNow) func.apply(context, args);
                };
            };
            window.addEventListener('resize', debounce(() =>
                reference.invokeMethodAsync('OnWindowResize', window.innerWidth)
                , 200, false), false);
        }
    }
}