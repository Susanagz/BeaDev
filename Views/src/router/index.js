import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../Home.vue'
//import Login from '../Login.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
  },
  /*{
    path: '/Login',
    name: 'Login',
    component: Login,
  }*/
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

<<<<<<< HEAD
/*router.beforeEach((to, from, next) => {
  if (to.name !== 'Login' && localStorage.getItem('jwt') == null)
    next({ name: 'Login' })
  else if (to.name === 'Login' && localStorage.getItem('jwt') !== null)
    next({ name: 'Home' })
  else
    next()
})*/
=======
// router.beforeEach((to, from, next) => {
//   // if (to.name !== 'Login' && localStorage.getItem('jwt') == null)
//   //   next({ name: 'Login' })
//   if (to.name === 'Login')
//      next({ name: 'Home' })
//   // else
//   //   next()
// })
>>>>>>> b153090f242a2b1a12277a0d85d8e692ed532705

export default router
