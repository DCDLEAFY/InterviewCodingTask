/** 
* @vitest-environment happy-dom
*/

import { mount, shallowMount } from "@vue/test-utils" 
import { describe, it, expect } from 'vitest';
import BrokerNavbar from "../src/components/BrokerNavbar.vue"



describe("Navbar Emit Test", () => {
    it("Should emit 'navadd' on press", () => {
        const wrapper = shallowMount(BrokerNavbar);
        const btn = wrapper.find('#addEvent');
        expect(btn.exists()).toBeTruthy()
        btn.trigger('click');
        expect(wrapper.emitted('navadd').length).toBe(1)
    })

    it("Should emit 'navdelete' on press", () => {
        const wrapper = shallowMount(BrokerNavbar);
        const btn = wrapper.find('#deleteEvent');
        expect(btn.exists()).toBeTruthy()
        btn.trigger('click');
        expect(wrapper.emitted('navdelete').length).toBe(1)
    })

    it("Should emit 'navrefresh' on press", () => {
        const wrapper = shallowMount(BrokerNavbar);
        const btn = wrapper.find('#getEvent');
        expect(btn.exists()).toBeTruthy()
        btn.trigger('click');
        expect(wrapper.emitted('navrefresh').length).toBe(1)
    })
})

// describe("Navbar Filter test", () => {
//     it("Shoudl ")
// })