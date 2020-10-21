import Vue from 'vue';

const clickOutside = {
    priority: 700,
    bind () {
      let self  = this
      this.event = function (event) { 
          self.vm.$emit(self.expression,event) 
         }
      this.el.addEventListener('click', this.stopProp)
      document.body.addEventListener('click',this.event)
    },
    
    unbind() {
      this.el.removeEventListener('click', this.stopProp)
      document.body.removeEventListener('click',this.event)
    },
    stopProp(event) {event.stopPropagation() }
};


export default {
    clickOutside,
};

Vue.directive('clickOutside', clickOutside);

