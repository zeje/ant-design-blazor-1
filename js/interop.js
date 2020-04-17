window.antdesign = {

    tooltip: function (componentReference, tooltip, target, placement, showDelay, hideDelay, triggers) {
        let popperInstance = null;

        function create() {
            popperInstance = Popper.createPopper(target, tooltip, {
                placement: placement,
                modifiers: {
                    flip: {
                        behavior: "flip"
                    },
                    preventOverflow: {
                        boundary: "scrollParent"
                    }

                }
            });
        }
        function destroy() {
            if (popperInstance) {
                popperInstance.destroy();
                popperInstance = null;
            }
        }

        function show() {
            setTimeout(() => {
                tooltip.classList.remove('ant-tooltip-hidden');;
                target.classList.add('ant-tooltip-open');;
                create();
                componentReference.invokeMethodAsync("OnTrigger",true);
            }, showDelay);
        }

        function hide() {
            setTimeout(() => {
                tooltip.classList.add('ant-tooltip-hidden');
                target.classList.remove('ant-tooltip-open');
                componentReference.invokeMethodAsync("OnTrigger",false);
                destroy();
            }, hideDelay);
        }
        function toggle() {
            if (target.classList.contains("ant-tooltip-open")) {
                hide();
            } else {
                show();
            }
        }
        const showEvents = [];
        const hideEvents = [];

        if (triggers.includes("hover")) {
            showEvents.push("mouseenter")
            hideEvents.push("mouseleave")
        }

        if (triggers.includes("focus")) {
            showEvents.push("focusin")
            hideEvents.push("focusout")
        }

        showEvents.forEach(event => {
            target.addEventListener(event, show);
        });

        hideEvents.forEach(event => {
            target.addEventListener(event, hide);
        });

        if (triggers.includes("click")) {
            target.addEventListener("click",toggle)
        }
        // Move the tooltip as a direct child of the body element and make sure we don't have to worry about the position of it's parent.
        document.body.appendChild(tooltip);
    },
}