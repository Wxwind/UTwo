# UTwo
基于MVI思想的UI框架(响应式编程/单向数据流动)

1.M->V基于MVVM的绑定思想，Model数据变化自动通知View发生变化

2.V->M基于MVC的思想，View通过Controller（unity中则可以使用eventsystem绑定action，我在示例中直接将Controller的逻辑写在View里面了）控制Model的变化

3.所以我觉得称这个设计思想为MVCM更容易理解。从左往右表示数据单向流动的方向：M->V和V->C->M

TODO:

1.UI全局管理器,管理View的生命周期
