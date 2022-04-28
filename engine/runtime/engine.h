#include "core/base/singleton.h"
namespace zeus{
    class engine : public singleton<engine>
    {
        //����ΪʲôҪ��Ϊ��Ԫ������
        friend class singleton<engine>;
        protected:
            engine();
        public:
            virtual ~engine();
            engine(const engine&) = delete;
            engine& operator=(const engine&) = delete;
            void run();
    };
    
}