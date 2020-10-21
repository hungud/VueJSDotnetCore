﻿import Vue from 'vue';

const clickOutside = {
    bind: function (el, binding, vnode) {
        this.event = function (event) {
            if (!(el == event.target || el.contains(event.target))) {
                vnode.context[binding.expression](event);
            }
        };
        document.body.addEventListener('click', this.event)
    },
    unbind: function () {
        document.body.removeEventListener('click', this.event)
    }
};

export default {
    clickOutside,
};

Vue.directive('clickOutside', clickOutside);

